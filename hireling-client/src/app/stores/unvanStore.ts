import { makeAutoObservable } from "mobx";
import agent from "../api/agent";
import { Unvan } from "../models/unvan";

export default class UnvanStore {
  unvanlar: Unvan[] = [];
  constructor() {
    makeAutoObservable(this);
  }

  loadUnvanlar = async () => {
    try {
      const unvanlar = await agent.Unvanlar.list();
      this.setunvanlar([]);
      unvanlar.forEach((u) => {
        this.setunvanlar([...this.unvanlar,u]);
      });     
    } catch (error) {
      console.log(error);
    }
  };
  setunvanlar = (unvanlar:Unvan[])=>{
    this.unvanlar=unvanlar;
  }
}
