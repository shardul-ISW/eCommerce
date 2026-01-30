/* eslint-disable @typescript-eslint/no-unsafe-assignment */
import apiClient from "~/axios_instance";
import type { BuyerOrderResponseDto } from "~/types/ResponseDto";
import type { Route } from "./+types/view_orders";
import { Card, CardContent, CardHeader } from "~/components/ui/card";
import { Badge } from "~/components/ui/badge";
import { Package, MapPin, Hash } from "lucide-react";

export async function clientLoader() {
  const response = await apiClient.get(`/buyer/orders`);
  const orders: BuyerOrderResponseDto[] = response.data;
  return { orders };
}

export default function OrdersPage({ loaderData }: Route.ComponentProps) {
  const { orders } = loaderData;

  if (!orders.length) {
    return (
      <div className="flex flex-col items-center justify-center p-12 text-muted-foreground">
        <Package className="h-12 w-12 mb-4 opacity-20" />
        <p>You have no orders yet.</p>
      </div>
    );
  }

  return (
    <div className="mx-auto max-w-4xl p-6">
      <h1 className="mb-8 text-3xl font-bold tracking-tight">Order History</h1>

      <div className="grid gap-4">
        {orders.map((order) => (
          <Card key={`${order.orderId}-${order.productId}`} className="overflow-hidden">
            <CardHeader className="bg-muted/30 pb-3 pt-3 flex flex-row items-center justify-between space-y-0">
              <div className="flex items-center gap-2 text-sm font-mono text-muted-foreground">
                <Hash className="h-3 w-3" />
                <span>Order {order.orderId}</span>
              </div>
              <Badge variant="outline" className="bg-background">Confirmed</Badge>
            </CardHeader>

            <CardContent className="p-5">
              <div className="flex flex-col md:flex-row justify-between gap-4">
                {/* Product Info */}
                <div className="space-y-1">
                  <h3 className="font-bold text-lg">{order.productName}</h3>
                  <div className="flex items-center gap-4 text-sm text-muted-foreground">
                    <span>SKU: <span className="text-foreground">{order.productSku}</span></span>
                    <span>Qty: <span className="text-foreground">{order.productCount}</span></span>
                  </div>
                </div>

                {/* Price Info */}
                <div className="text-right">
                  <p className="text-xs text-muted-foreground uppercase font-semibold tracking-wider">Total Paid</p>
                  <p className="text-2xl font-black text-primary">
                    ${order.orderValue.toFixed(2)}
                  </p>
                </div>
              </div>

              {/* Address Footer */}
              <div className="mt-4 pt-4 border-t flex items-start gap-2 text-sm text-muted-foreground">
                <MapPin className="h-4 w-4 mt-0.5 shrink-0" />
                <p>Shipping to: <span className="text-foreground">{order.deliveryAddress}</span></p>
              </div>
            </CardContent>
          </Card>
        ))}
      </div>
    </div>
  );
}


