/* eslint-disable @typescript-eslint/no-misused-promises */
import type { Route } from "./+types/home";
import { Button } from "~/components/ui/button";
import { useNavigate } from "react-router";
// eslint-disable-next-line no-empty-pattern
export function meta({}: Route.MetaArgs) {
  return [
    { title: "New React Router App" },
    { name: "description", content: "Welcome to React Router!" },
  ];
}

export default function Home() {
  const navigate = useNavigate();

  return (
    <div className="flex w-full h-screen justify-center items-center">
      <div className="flex flex-col gap-6 border-2 w-3/12 h-auto p-6 rounded-xl">
        <Button onClick={() => navigate("/auth/buyer/login")}>Login as buyer</Button> 
        <Button>Register as buyer</Button>
        <Button>Login as seller</Button>
        <Button>Register as seller</Button>
      </div>
    </div>
  );
}
