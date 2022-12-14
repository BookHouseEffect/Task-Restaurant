import React, { createContext } from 'react';

export interface UserModel {
  id?: string;
  displayName?: string;
  userName?: string;
  restaurant?: {
    id: number;
    restaurantName: string;
    numberOfTables: number;
  };
  token?: string;
}

export interface UserContextModel {
  user: UserModel;
  setUser: React.Dispatch<React.SetStateAction<UserModel>>;
}

export const UserContext = createContext<UserContextModel>({ user: {}, setUser: () => { }});
