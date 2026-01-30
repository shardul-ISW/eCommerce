import { redirect } from "react-router";
import apiClient from "~/axios_instance";

export async function clientAction() {
  await apiClient.post(`buyer/cart`);
  return redirect(`/buyer/orders`);
}