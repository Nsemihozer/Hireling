import { Departman } from "./departman";
import { Unvan } from "./unvan";

export interface Calisan {
  CalisanID: number;
  Adi: string;
  Soyadi: string;
  TcNo: string;
  SSkNo: string;
  DogumTarihi: string;
  IseGirisTarihi: string;
  FirmaID: number;
  BirimID?: number;
  UnvanID?: number;
  Cinsiyet: number|null;
  Medeni: number|null;
  KullaniciAdi: string;
  Sifre: string;
  Telefon: string;
  BrutMaas: number|null;
  NetMaas: number|null;
  IzinSaat: number|null;
  KullanilanIzinSaat: number|null;
  IzinGun: number|null;
  KullanilanIzinGun: number|null;

}
