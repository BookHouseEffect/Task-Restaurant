import React from "react";
import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../../authConfig";
import Button from "react-bootstrap/Button";


/**
 * Renders a button which, when selected, will open a popup for login
 */
export const SignInButtonPopup = () => {
  const { instance } = useMsal();

  const handleLogin = (loginType: any) => {
    if (loginType === "popup") {
      instance.loginPopup(loginRequest).catch(e => {
        console.log(e);
      });
    }
  }

  return (
    <Button
      variant="secondary"
      className="ml-auto"
      onClick={() => handleLogin("popup")}>
        Sign In
    </Button>
  );
}

/**
 * Renders a button which, when selected, will redirect the page to the login prompt
 */
export const SignInButtonRedirect = () => {
  const { instance } = useMsal();

  const handleLogin = (loginType: any) => {
    if (loginType === "redirect") {
      instance.loginRedirect(loginRequest).catch(e => {
        console.log(e);
      });
    }
  }
  return (
    <Button
      variant="secondary"
      className="ml-auto"
      onClick={() => handleLogin("redirect")}>
        Sign In
    </Button>
  );
}