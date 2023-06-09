import { AUTH_TOKEN_NAME } from "@/config/constants";
import { pages } from "@/helpers/pages";
import type { NextRequest } from "next/server";
import { NextResponse } from "next/server";

export async function middleware(request: NextRequest) {
  const token = request.cookies.get(AUTH_TOKEN_NAME)?.value;

  const nextPathname = request.nextUrl.pathname;

  const isPublicPage =
    nextPathname === pages.auth.login.path ||
    nextPathname === pages.auth.register.path ||
    nextPathname === pages.public.landing.path;

  if (!!token && !isPublicPage) {
    return NextResponse.next();
  }
  if (!!token && isPublicPage) {
    return NextResponse.redirect(
      new URL(pages.dashboard.home.path, request.url)
    );
  }

  return NextResponse.next();
}

export const config = {
  matcher: "/((?!_next|static|public|favicon.ico).*)",
};
