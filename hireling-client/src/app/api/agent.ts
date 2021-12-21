import axios, { AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { setTimeout } from "timers";
import { history } from "../..";
import { Calisan } from "../models/calisan";
import { User } from "../models/User";
import { Unvan } from "../models/unvan";
import { store } from "../stores/store";

const sleep = (delay: number) => {
  return new Promise((resolve) => {
    setTimeout(resolve, delay);
  });
};

axios.defaults.baseURL = "http://localhost:5000/api/";

axios.interceptors.request.use(config => {
  const token = store.commonStore.token;
 
  if (token)  config.headers = {
    Authorization: `Bearer ${token}`
};
  return config;
})

axios.interceptors.response.use(
  async (response) => {
    await sleep(1000);
    return response;
  },
  (error: AxiosError) => {
    const { data, status, config, headers } = error.response!;

    switch (status) {
      case 400:
          if(data.errors){
              const modalStateErrors=[];
              for (const key in data.errors) {
                if(data.errors[key]){
                    modalStateErrors.push(data.errors[key]);
                }
              }
              throw modalStateErrors.flat();
          }
          else{
            toast.error(data);
          }       
        break;
      case 401:
        if (status === 401 && headers['www-authenticate']?.startsWith('Bearer error="invalid_token"')) {
          store.userStore.logout();
          toast.error('Session expired - please login again');
      }
      break;
      case 404:
        history.push('/notfound');
        break;
      case 500:
        store.commonStore.setServerError(data);
        history.push('/server-error');
        break;
      default:
        toast.error("server hatası");
        break;
    }
    return Promise.reject(error);
  }
);

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) =>
    axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
  del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const Calisanlar = {
  list: () => requests.get<Calisan[]>("/calisanlar"),
  details: (id: number) => requests.get<Calisan>(`/calisanlar/${id}`),
  create: (calisan: any,sifre:string) => requests.post<number>("/calisanlar", {calisanData: calisan,password:sifre}),
  update: (calisan: Calisan) =>
    requests.put<void>(`/calisanlar/${calisan.Id}`, calisan),
  delete: (id: number) => requests.del<void>(`/calisanlar/${id}`),
};

const Account = {
  current: () => requests.get<User>("/account"),
  login:(user:User) => requests.post<User>("/account/login",user)
}

const Unvanlar = {
  list: () => requests.get<Unvan[]>("/unvanlar"),
  details: (id: number) => requests.get<Unvan>(`/unvanlar/${id}`),
  create: (unvan: Unvan) => requests.post<number>("/unvanlar", unvan),
  update: (unvan: Unvan) =>
    requests.put<void>(`/unvanlar/${unvan.UnvanID}`, unvan),
  delete: (id: number) => requests.del<void>(`/unvanlar/${id}`),
};

const agent = {
  Calisanlar,
  Unvanlar,
  Account
};

export default agent;
