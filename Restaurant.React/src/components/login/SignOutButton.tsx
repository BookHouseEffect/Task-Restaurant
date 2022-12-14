import React from "react";
import { useMsal } from "@azure/msal-react";
import Button from "react-bootstrap/Button";

/**
 * Renders a button which, when selected, will open a popup for logout
 */
export const SignOutButtonPopup = () => {
  const { instance } = useMsal();

  const handleLogout = (logoutType: any) => {
    if (logoutType === "popup") {
      instance.logoutPopup({
        postLogoutRedirectUri: "/",
        mainWindowRedirectUri: "/" // redirects the top level app after logout
      });
    }
  }

  return (
    <Button
      variant="secondary"
      className="ml-auto"
      onClick={() => handleLogout("popup")}>
        Sign Out
    </Button>
  );
}

/**
 * Renders a button which, when selected, will redirect the page to the logout prompt
 */
export const SignOutButtonRedirect = () => {
  const { instance } = useMsal();

  const handleLogout = (logoutType:any) => {
    if (logoutType === "redirect") {
      instance.logoutRedirect({
        postLogoutRedirectUri: "/",
      });
    }
  }

  return (
    <Button
      variant="secondary"
      className="ml-auto"
      onClick={() => handleLogout("redirect")}>
        Sign Out
    </Button>
  );
}