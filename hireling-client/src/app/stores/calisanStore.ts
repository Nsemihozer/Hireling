import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Calisan } from "../models/calisan";

export default class CalisanStore {
  calisanlarRegistry = new Map<number, Calisan>();
  selectedCalisan: Calisan | undefined = undefined;
  editMode = false;
  loading = false;
  loadingInitial = true;

  constructor() {
    makeAutoObservable(this);
  }

  get getCalisanlarByAd() {
    return Array.from(this.calisanlarRegistry.values()).sort(
      (a, b) => Date.parse(a.IseGirisTarihi) - Date.parse(b.IseGirisTarihi)
    );
  }

  get CalisanlarByUnvan() {
    return Array.from(this.calisanlarRegistry.values()).sort(
      (a, b) => {
        if (a.UnvanID === b.UnvanID) {
          return 0;
      }
      // nulls sort after anything else
      else if (a.UnvanID === null) {
          return 1;
      }
      else if (b.UnvanID === null) {
          return 1;
      }
      // otherwise, if we're ascending, lowest sorts first
      else {
          return a.UnvanID < b.UnvanID ? -1 : 1;
      }
      }
    );
  }

  get GroupedCalisan(){
    return Object.entries(
      this.CalisanlarByUnvan.reduce((calisanlar,calisan)=>{
        const unvan =calisan.UnvanID ? calisan.UnvanID : 0;

        calisanlar[unvan]=calisanlar[unvan] ? [...calisanlar[unvan],calisan]:[calisan];
        return calisanlar;
      },{} as {[key:number]: Calisan[]})
    )
  }




  loadCalisanlar = async () => {
    this.setLoadingInitial(true);
    try {
      const calisanlar = await agent.Calisanlar.list();
      calisanlar.forEach((calisan) => {
        this.setCalisan(calisan);
      });
      this.setLoadingInitial(false);
    } catch (error) {
      console.log(error);
      this.setLoadingInitial(false);
    }
  };

  loadCalisan = async (id: number) => {
    let calisan = this.getCalisan(id);
    if (calisan) {
      this.selectedCalisan = calisan;
      return calisan;
    } else {
      this.setLoadingInitial(true);
      try {
        calisan = await agent.Calisanlar.details(id);
        this.setCalisan(calisan);
        runInAction(()=>{
          this.selectedCalisan=calisan;
        })
        
        this.setLoadingInitial(false);
        return calisan;
      } catch (error) {
        console.log(error);
        this.setLoadingInitial(false);
      }
    }
  };

  private setCalisan = (calisan: Calisan) => {
    calisan.DogumTarihi = calisan.DogumTarihi.split("T")[0];
    calisan.IseGirisTarihi = calisan.IseGirisTarihi.split("T")[0];
    this.calisanlarRegistry.set(calisan.CalisanID, calisan);
  };

  private getCalisan = (id: number) => {
    return this.calisanlarRegistry.get(id);
  };

  setLoadingInitial = (state: boolean) => {
    this.loadingInitial = state;
  };

  setEditMode = (state: boolean) => {
    this.editMode = state;
  };

  setLoading = (state: boolean) => {
    this.loading = state;
  };

  createCalisan = async (calisan: Calisan) => {
    this.setLoading(true);
    try {
      if (calisan.IseGirisTarihi === "" || calisan.IseGirisTarihi ===undefined) {
        calisan.IseGirisTarihi = new Date().toISOString();
      }
      const id = await agent.Calisanlar.create(calisan);
      calisan.CalisanID = id;
      runInAction(() => {
        this.calisanlarRegistry.set(calisan.CalisanID, calisan);
      });
      this.setEditMode(false);
      this.setLoading(false);
      return id;
    } catch (error) {
      console.log(error);
    }
  };

  editCalisan = async (calisan: Calisan) => {
    this.setLoading(true);
    try {
      await agent.Calisanlar.update(calisan);
      runInAction(() => {
        this.calisanlarRegistry.set(calisan.CalisanID, calisan);
      });
      this.setEditMode(false);
      this.setLoading(false);
    } catch (error) {
      console.log(error);
      this.setLoading(false);
    }
  };

  deleteCalisan = async (id: number) => {
    this.setLoading(true);
    try {
      await agent.Calisanlar.delete(id);
      runInAction(() => {
        this.calisanlarRegistry.delete(id);
      });
      this.setLoading(false);
    } catch (error) {
      console.log(error);
      this.setLoading(false);
    }
  };
}
