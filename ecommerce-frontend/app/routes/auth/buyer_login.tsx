import { Form, redirect } from "react-router";
import { Button } from "~/components/ui/button";
import { Field, FieldLabel } from "~/components/ui/field";
import { Input } from "~/components/ui/input";
import type { Route } from "./+types/buyer_login";
import { sendBuyerLoginRequest } from "~/services/AuthService";

export async function clientAction({ request }: Route.ActionArgs) {
  const formData = await request.formData();
  await sendBuyerLoginRequest(formData);
  return redirect("/buyer");
}

export default function BuyerLoginPage() {
  return (
    <Form method="post">
      <Field>
        <FieldLabel>Email</FieldLabel>
        <Input name="email" placeholder="Enter your email" type="text" />
      </Field>
      <Field>
        <FieldLabel>Password</FieldLabel>
        <Input name="password" placeholder="Enter your password" type="text" />
      </Field>
      <Button type="submit">Submit</Button>
    </Form>
  );
}
