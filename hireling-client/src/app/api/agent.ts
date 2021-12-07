import axios, {  AxiosResponse } from "axios";
import { setTimeout } from "timers";
import { Calisan } from "../models/calisan";
import { Unvan } from "../models/unvan";

const sleep=(delay:number)=>{
    return new Promise((resolve)=>{
        setTimeout(resolve,delay);
    })
}

axios.defaults.baseURL= 'http://localhost:5000/api/';
axios.interceptors.response.use(async response=>{
    try {
        await sleep(1000);
        return response;
    } catch (error) {
        console.log(error);
        return await Promise.reject(error);
    }
})

const responseBody=<T>(response:AxiosResponse<T>) => response.data;

const requests = {
    get : <T>(url:string)=>axios.get<T>(url).then(responseBody),
    post :<T>(url:string,body:{})=>axios.post<T>(url,body).then(responseBody),
    put :<T>(url:string,body:{})=>axios.put<T>(url,body).then(responseBody),
    del :<T>(url:string)=>axios.delete<T>(url).then(responseBody),
}

const Calisanlar ={
    list:()=>requests.get<Calisan[]>('/calisanlar'),
    details: (id:number) => requests.get<Calisan>(`/calisanlar/${id}`),
    create:(calisan:Calisan)=>requests.post<number>('/calisanlar',calisan),
    update:(calisan:Calisan)=>requests.put<void>(`/calisanlar/${calisan.CalisanID}`,calisan),
    delete: (id:number) => requests.del<void>(`/calisanlar/${id}`),
}

const Unvanlar ={
    list:()=>requests.get<Unvan[]>('/unvanlar'),
    details: (id:number) => requests.get<Unvan>(`/unvanlar/${id}`),
    create:(unvan:Unvan)=>requests.post<number>('/unvanlar',unvan),
    update:(unvan:Unvan)=>requests.put<void>(`/unvanlar/${unvan.UnvanID}`,unvan),
    delete: (id:number) => requests.del<void>(`/unvanlar/${id}`),
}

const agent = {
    Calisanlar,
    Unvanlar
}

export default agent;