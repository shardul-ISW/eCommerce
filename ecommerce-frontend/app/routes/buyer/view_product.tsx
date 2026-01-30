/* eslint-disable @typescript-eslint/no-unsafe-assignment */
import { useState } from "react";
import type { BuyerProductResponseDto } from "~/types/ResponseDto";
import type { Route } from "./+types/view_product";
import apiClient from "~/axios_instance";
import { useFetcher } from "react-router";
import { Button } from "~/components/ui/button";
import { Card, CardContent, CardHeader } from "~/components/ui/card";
import { Minus, Plus, ShoppingCart, Check } from "lucide-react"; // Assuming lucide-react is available

export async function clientLoader({ params }: Route.ClientLoaderArgs) {
  const productId: string = params.productId;
  const response = await apiClient.get(`/buyer/products/${productId}`);
  const productDto: BuyerProductResponseDto = response.data;
  return { productDto };
}

export async function clientAction({ params, request }: Route.ClientActionArgs) {
  const formData = await request.formData();
  const quantity = formData.get("quantity");
  const productId = params.productId;

  await apiClient.post(`/buyer/cart/${productId}?count=${quantity}`);
  return { success: true };
}

export default function ProductDisplay({ loaderData }: Route.ComponentProps) {
  const { productDto } = loaderData;
  const fetcher = useFetcher();
  const [quantity, setQuantity] = useState(1);

  // Check if the fetcher is currently submitting
  const isSubmitting = fetcher.state !== "idle";
  const isSuccess = fetcher.data?.success;

  const handleIncrement = () => {
    if (quantity < productDto.countInStock) {
      setQuantity((prev) => prev + 1);
    }
  };

  const handleDecrement = () => {
    if (quantity > 1) {
      setQuantity((prev) => prev - 1);
    }
  };

  return (
    <div className="mx-auto max-w-6xl px-6 pt-6">
      <Card className="grid grid-cols-1 md:grid-cols-2 gap-6 overflow-hidden">
        {/* Image Section */}
        <div className="flex items-center justify-center bg-muted/50 rounded-l-lg h-[400px] md:h-full">
          {productDto.images ? (
            <img
              src={productDto.images}
              alt={productDto.name}
              className="max-h-full w-full object-contain p-4"
            />
          ) : (
            <span className="text-muted-foreground">No image available</span>
          )}
        </div>

        {/* Details Section */}
        <div className="flex flex-col gap-6 p-6">
          <CardHeader className="p-0">
            <div className="space-y-1">
              <h1 className="text-3xl font-bold tracking-tight">{productDto.name}</h1>
              <p className="text-sm text-muted-foreground font-mono">
                SKU: {productDto.sku}
              </p>
            </div>
          </CardHeader>

          <CardContent className="p-0 flex flex-col gap-6">
            <div className="flex items-baseline gap-2">
              <span className="text-4xl font-bold text-primary">
                ${productDto.price.toFixed(2)}
              </span>
            </div>

            <div className="space-y-2">
              <p className="text-sm font-medium">
                {productDto.countInStock > 0 ? (
                  <span className="text-green-600 flex items-center gap-1">
                    <span className="relative flex h-2 w-2">
                      <span className="animate-ping absolute inline-flex h-full w-full rounded-full bg-green-400 opacity-75"></span>
                      <span className="relative inline-flex rounded-full h-2 w-2 bg-green-500"></span>
                    </span>
                    {productDto.countInStock} items in stock
                  </span>
                ) : (
                  <span className="text-red-600">Out of stock</span>
                )}
              </p>
              {productDto.description && (
                <p className="text-muted-foreground leading-relaxed">
                  {productDto.description}
                </p>
              )}
            </div>

            {productDto.countInStock > 0 && (
              <div className="space-y-4 pt-4 border-t">
                <label className="text-sm font-semibold">Quantity</label>
                <div className="flex items-center gap-4">
                  {/* Quantity Selector */}
                  <div className="flex items-center border rounded-lg p-1 bg-background">
                    <Button
                      variant="ghost"
                      size="icon"
                      className="h-8 w-8"
                      onClick={handleDecrement}
                      disabled={quantity <= 1 || isSubmitting}
                    >
                      <Minus className="h-4 w-4" />
                    </Button>
                    <span className="w-10 text-center font-medium">
                      {quantity}
                    </span>
                    <Button
                      variant="ghost"
                      size="icon"
                      className="h-8 w-8"
                      onClick={handleIncrement}
                      disabled={quantity >= productDto.countInStock || isSubmitting}
                    >
                      <Plus className="h-4 w-4" />
                    </Button>
                  </div>

                  {/* Add to Cart Button */}
                  <fetcher.Form method="post" className="flex-1">
                    <input type="hidden" name="quantity" value={quantity} />
                    <Button
                      type="submit"
                      className="w-full transition-all"
                      disabled={isSubmitting}
                      variant={isSuccess ? "outline" : "default"}
                    >
                      {isSubmitting ? (
                        "Adding..."
                      ) : isSuccess ? (
                        <>
                          <Check className="mr-2 h-4 w-4 text-green-600" /> Added to Cart
                        </>
                      ) : (
                        <>
                          <ShoppingCart className="mr-2 h-4 w-4" /> Add to Cart
                        </>
                      )}
                    </Button>
                  </fetcher.Form>
                </div>
              </div>
            )}
          </CardContent>
        </div>
      </Card>
    </div>
  );
}
