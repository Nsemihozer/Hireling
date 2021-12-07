import { createContext, useContext } from "react";
import CalisanStore from "./calisanStore";
import UnvanStore from "./unvanStore";

interface Store{
    calisanStore:CalisanStore,
    unvanStore:UnvanStore
}

export const store:Store={
    calisanStore:new CalisanStore(),
    unvanStore:new UnvanStore()
}
export const StoreContext=createContext(store);

export function useStore() {
    return useContext(StoreContext);
}