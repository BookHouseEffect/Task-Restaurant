import React, { useState, useMemo, useContext, useEffect } from "react";
import { PageLayout } from './components/login/PageLayout';
import { AuthenticatedTemplate, useMsal } from "@azure/msal-react";
import { loginRequest } from "./authConfig";

import TableManagement from './components/table-management/TableManagement';
import './App.css';
import { Button } from "react-bootstrap";
import { UserContext, UserModel } from "./components/context/UserContext";
import UserService from "./components/context/UserService";

function ProfileContent() {
  const { instance, accounts, inProgress } = useMsal();
  const [accessToken, setAccessToken] = useState(null);
  const { user, setUser } = useContext(UserContext);
  
  const name = accounts[0] && accounts[0].name;

  function RequestAccessToken() {
    const request = {
      ...loginRequest,
      account: accounts[0]
    };

    // Silently acquires an access token which is then attached to a request for Microsoft Graph data
    return instance.acquireTokenSilent(request).then((response: any) => {
      setAccessToken(response.accessToken);
      return response.accessToken;
    }).catch((e: any) => {
      return instance.acquireTokenRedirect(request).then((response: any) => {
        setAccessToken(response.accessToken);
        return response.accessToken
      });
    });
  };

  useEffect(() => {
    RequestAccessToken().then((token) => {
      new UserService(token).getUser()
        .then((data: any) => {
          setUser({
            id: data.id,
            displayName: data.displayName,
            restaurant: {
              id: data.restaurant.id,
              restaurantName: data.restaurant.restaurantName,
              numberOfTables: data.restaurant.numberOfTables
            },
            token: token
          });
        }).catch((er: any) => {
          console.log(er)
        });
    })
  }, [])

  return (
    <h2 className="card-title">Welcome {user.displayName} @ {user.restaurant?.restaurantName || ''}</h2>
  );
};

function App() {
  const [user, setUser] = useState<UserModel>({});
  const value = useMemo(() => ({ user, setUser }), [user, setUser]);

  return (
    <PageLayout>
      <AuthenticatedTemplate>
        <UserContext.Provider value={value}>
          <div className="App">
            <header className="App-header">
              <ProfileContent />
            </header>
            <div>
              <TableManagement />
            </div>
          </div>
        </UserContext.Provider>
      </AuthenticatedTemplate>
    </PageLayout>
  );
}

export default App;
