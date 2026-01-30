/* eslint-disable @typescript-eslint/no-unsafe-assignment */
import apiClient from "~/axios_instance";
import invariant from "tiny-invariant";
import { redirect } from "react-router";
import type { Route } from "./+types/delete_from_cart";

export async function clientAction({ params }: Route.ClientActionArgs) {
  invariant(params.productId, "Missing productId parameter");
  await apiClient.delete(`/buyer/cart/${params.productId}`);
  return null;
}