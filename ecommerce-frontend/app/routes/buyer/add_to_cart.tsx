/* eslint-disable @typescript-eslint/no-unsafe-assignment */
import apiClient from "~/axios_instance";
import type { Route } from "./+types/add_to_cart";
import invariant from "tiny-invariant";
import { redirect } from "react-router";

export async function clientAction({ params }: Route.ClientActionArgs) {
  invariant(params.productId, "Missing productId parameter");
  await apiClient.post(`/buyer/cart/${params.productId}?count=1`);
  return redirect(`/buyer/products/${params.productId}`);
}
