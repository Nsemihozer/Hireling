import { createContext, useContext } from "react";
import CalisanStore from "./calisanStore";
import CommonStore from "./commonStore";
import ModalStore from "./modalStore";
import UnvanStore from "./unvanStore";
import UserStore from "./userStore";

interface Store{
    calisanStore:CalisanStore,
    unvanStore:UnvanStore,
    commonStore:CommonStore,
    userStore:UserStore,
    modalStore:ModalStore
}

export const store:Store={
    calisanStore:new CalisanStore(),
    unvanStore:new UnvanStore(),
    commonStore:new CommonStore(),
    userStore:new UserStore(),
    modalStore: new ModalStore()
}
export const StoreContext=createContext(store);

export function useStore() {
    return useContext(StoreContext);
}