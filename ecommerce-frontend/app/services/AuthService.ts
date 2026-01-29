import { redirect } from "react-router";
import apiClient from "~/axios_instance";

export async function sendBuyerLoginRequest(formData: FormData) {
  const response = await apiClient.post("/auth/buyer/login", formData);
  localStorage.setItem("accessToken", response.data.accessToken); //eslint-disable-line
  return redirect("/buyer");
}
