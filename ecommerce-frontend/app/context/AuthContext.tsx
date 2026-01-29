// // AuthContext.tsx
// import { createContext, useContext, useMemo } from "react";
// import jwt from "jsonwebtoken";

// type AuthContextValue = {
//   isAuthenticated: boolean;
//   user: ReturnType<typeof getUser>;
// };

// const AuthContext = createContext<AuthContextValue | null>(null);

// export function AuthProvider({ children }: { children: React.ReactNode }) {
//   const token = localStorage.getItem("accessToken");
//   const payload = jwt.decode(token);

//   const value = useMemo(
//     () => ({
//       isAuthenticated: !!token,
//       user,
//     }),
//     [token],
//   );

//   return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
// }

// export function useAuth() {
//   const ctx = useContext(AuthContext);
//   if (!ctx) throw new Error("useAuth must be used inside AuthProvider");
//   return ctx;
// }
