import { createContext, useContext } from "react";
import CalisanStore from "./calisanStore";
import CommonStore from "./commonStore";
import UnvanStore from "./unvanStore";

interface Store{
    calisanStore:CalisanStore,
    unvanStore:UnvanStore,
    commonStore:CommonStore
}

export const store:Store={
    calisanStore:new CalisanStore(),
    unvanStore:new UnvanStore(),
    commonStore:new CommonStore()

}
export const StoreContext=createContext(store);

export function useStore() {
    return useContext(StoreContext);
}