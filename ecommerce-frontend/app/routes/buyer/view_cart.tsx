/* eslint-disable @typescript-eslint/no-unsafe-assignment */
import apiClient from "~/axios_instance";
import type { BuyerCartItemResponseDto } from "~/types/ResponseDto";
import type { Route } from "./+types/view_cart";
import { Form, useFetcher } from "react-router";
import { Card, CardContent, CardFooter } from "~/components/ui/card";
import { Button } from "~/components/ui/button";
import { CreditCard, Minus, Plus, ShoppingBag, Trash2 } from "lucide-react";

export async function clientLoader() {
  const response = await apiClient.get(`/buyer/cart`);
  const cartItems: BuyerCartItemResponseDto[] = response.data;
  return { cartItems };
}

export async function clientAction({
  request,
}: Route.ActionArgs) {
  const formData = await request.formData();

  const productId = formData.get("productId") as string;
  const count = Number(formData.get("count"));

  await apiClient.post(
    `/buyer/cart/${productId}?count=${count}`
  );

  return null; // triggers loader revalidation
}

export default function CartDisplay({ loaderData }: Route.ComponentProps) {
  const { cartItems } = loaderData;

  const cartTotal = cartItems.reduce(
    (acc, item) => acc + item.price * item.countInCart,
    0
  );

  if (cartItems.length === 0) {
    return (
      <div className="flex flex-col items-center justify-center p-12 text-muted-foreground">
        <ShoppingBag className="h-12 w-12 mb-4 opacity-20" />
        <p className="text-lg font-medium">Your cart is empty</p>
      </div>
    );
  }

  return (
    <div className="mx-auto max-w-3xl p-6 space-y-6">
      <h1 className="text-2xl font-bold">Shopping Cart</h1>
      
      <div className="space-y-4">
        {cartItems.map((item) => (
          <CartItem key={item.id} item={item} />
        ))}
      </div>

      <Card className="bg-muted/30">
        <CardContent className="p-6 space-y-4">
          <div className="flex justify-between text-lg font-semibold">
            <span>Order Total</span>
            <span>₹{cartTotal.toFixed(2)}</span>
          </div>
        </CardContent>
        <CardFooter className="p-6 pt-0">
          <Form action="place_order" method="post" className="w-full">
            <Button size="lg" className="w-full text-base font-bold">
              <CreditCard className="mr-2 h-5 w-5" />
              Place Order
            </Button>
          </Form>
        </CardFooter>
      </Card>
    </div>
  );
}

function CartItem({
  item,
}: {
  item: {
    id: string;
    name: string;
    price: number;
    countInCart: number;
  };
}) {
  const fetcher = useFetcher();
  const deleteFetcher = useFetcher(); // Separate fetcher for deletion

  const optimisticCount = fetcher.formData
    ? Number(fetcher.formData.get("count"))
    : item.countInCart;

  // If the item is being deleted, we can hide it optimistically
  const isDeleting = deleteFetcher.state !== "idle";

  if (isDeleting) return null;

  return (
    <Card>
      <CardContent className="flex items-center justify-between py-4">
        <div className="space-y-1">
          <div className="font-semibold">{item.name}</div>
          <div className="text-sm text-muted-foreground">
            ₹{item.price.toFixed(2)}
          </div>
        </div>

        <div className="flex items-center gap-6">
          {/* Quantity controls */}
          <div className="flex items-center gap-2">
            <fetcher.Form method="post">
              <input type="hidden" name="productId" value={item.id} />
              <input
                type="hidden"
                name="count"
                value={Math.max(optimisticCount - 1, 1)}
              />
              <Button
                variant="outline"
                size="icon"
                className="h-8 w-8"
                disabled={optimisticCount <= 1}
                type="submit"
              >
                <Minus className="h-3 w-3" />
              </Button>
            </fetcher.Form>

            <span className="w-8 text-center font-medium">
              {optimisticCount}
            </span>

            <fetcher.Form method="post">
              <input type="hidden" name="productId" value={item.id} />
              <input
                type="hidden"
                name="count"
                value={optimisticCount + 1}
              />
              <Button
                variant="outline"
                size="icon"
                className="h-8 w-8"
                type="submit"
              >
                <Plus className="h-3 w-3" />
              </Button>
            </fetcher.Form>
          </div>

          {/* Delete Button */}
          <deleteFetcher.Form 
            method="post" 
            action={`delete/${item.id}`}
          >
            <Button 
              variant="ghost" 
              size="icon" 
              className="text-destructive hover:bg-destructive/10"
              type="submit"
              title="Remove item"
            >
              <Trash2 className="h-5 w-5" />
            </Button>
          </deleteFetcher.Form>
        </div>
      </CardContent>
    </Card>
  );
}





