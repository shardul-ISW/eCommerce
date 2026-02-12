import apiClient from "~/axios_instance";

export async function clientAction() {
  const response = await apiClient.post(`buyer/cart`);
  const { checkoutUrl } = response.data as { checkoutUrl: string };

  // Redirect to Stripe's hosted checkout page
  window.location.href = checkoutUrl;

  // Return null — the redirect above navigates away from the SPA
  return null;
}
