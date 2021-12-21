import { makeAutoObservable, runInAction } from "mobx";
import { history } from "../..";
import agent from "../api/agent";
import { User } from "../models/User";
import { store } from "./store";


export default class UserStore {
    user:User|null=null;
    constructor() {
        makeAutoObservable(this);
    }

    get isLoggedIn(){
        return !!this.user;
    }

    login= async (creds:User)=>
    {
        try {
            const user = await agent.Account.login(creds);
            store.commonStore.setToken(user.Token!);
            runInAction(()=>{
                this.user=user;
            });
            history.push("/calisanlar");
            store.modalStore.closeModal()
        } catch (error) {
            throw error;
        }
    }

    logout= async ()=>
    {
        try {
            
            runInAction(()=>{
                this.user=null;
            });
            store.commonStore.setToken(null);
            window.localStorage.removeItem('jwt');
            history.push("/");
        } catch (error) {
            throw error;
        }
    }

    getUser = async () => {
        try {
            const user = await agent.Account.current();
            store.commonStore.setToken(user.Token!);
            runInAction(() => this.user = user);
            //this.startRefreshTokenTimer(user);
        } catch (error) {
            console.log(error);
        }
    }

}