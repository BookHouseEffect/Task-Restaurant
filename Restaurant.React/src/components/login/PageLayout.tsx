import React from "react";
import Navbar from "react-bootstrap/Navbar";
import { useIsAuthenticated } from "@azure/msal-react";
import { SignInButtonRedirect } from "./SignInButton";
import { SignOutButtonRedirect } from "./SignOutButton";
import './Login.css';

/**
 * Renders the navbar component with a sign-in button if a user is not authenticated
 */
export const PageLayout = (props:any) => {
  const isAuthenticated = useIsAuthenticated();

  return (
    <>
      <div className="navigationBar">
        <Navbar>
          {isAuthenticated ? <SignOutButtonRedirect /> : <SignInButtonRedirect />}
        </Navbar>
      </div>
      {props.children}
    </>
  );
};