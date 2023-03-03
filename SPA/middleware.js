import { NextResponse } from "next/server"

const checkAuth = (request) => {
    const accessToken = request.cookies.get("access_token");
    // const refreshToken=request.cookies.get("refresh_token");
    if (!accessToken) {
        return false;
    }
    return true;
}


export const middleware = (request) => {
    
    const isAuth = checkAuth(request);
    if (!isAuth && !request.url.includes("login")) {
        return NextResponse.redirect(new URL("/auth/login",request.url));
    }
    if (isAuth && request.url.includes("login")) {
        return NextResponse.redirect(new URL("/",request.url));
    }
  
    return NextResponse.next();
}
export default middleware


export const config = {
    matcher: [
        //eğer assets, _next/static, favicon.ico  klasörüne giderse middleware çalışmasın
        "/((?!assets|_next/static|favicon.ico).*)",
    ]
}
