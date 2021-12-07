import { observer } from "mobx-react-lite";
import React, { ChangeEvent, SyntheticEvent, useEffect, useState } from "react";
import { Link, useHistory, useParams } from "react-router-dom";
import { Button, DropdownProps, Form, Segment } from "semantic-ui-react";
import LoadingCompnents from "../../../app/layout/LoadingComponent";
import { Calisan } from "../../../app/models/calisan";
import { useStore } from "../../../app/stores/store";

export default observer(function CalisanForm() {
  const { calisanStore, unvanStore } = useStore();
  const { createCalisan, loading, editCalisan, loadCalisan, loadingInitial } =
    calisanStore;
  const { unvanlar } = unvanStore;
  const { id } = useParams<{ id: string }>();

  const [calisan, setCalisan] = useState({} as Calisan);

 

  useEffect(() => {
    if (id) {
      loadCalisan(+id).then((calisan) => setCalisan(calisan!));
    }
  }, [id, loadCalisan]);

  const unvanOptions = () => {
    const options: { key: number; text: string; value: number }[] = [];
    unvanlar.forEach((u) => {
      options.push({ key: u.UnvanID, text: u.UnvanAdi, value: u.UnvanID });
    });
    return options;
  };
  const history = useHistory();
  function handleSubmit() {
    if (calisan.CalisanID) {
      editCalisan(calisan).then(()=>history.push(`/calisanlar/${calisan.CalisanID}`));
    } else {
      createCalisan(calisan).then((id)=> id !== undefined ? history.push(`/calisanlar/${id}`):alert("Hata oluştu"));
    }
  }

  function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
    const { name, value } = event.target;
    setCalisan({ ...calisan, [name]: value });
  }

  function handleSelectionChange(
    event: SyntheticEvent<HTMLElement, Event>,
    data: DropdownProps
  ) {
    setCalisan({ ...calisan, UnvanID: +data.value! });
  }

  if (loadingInitial) return <LoadingCompnents></LoadingCompnents>;

  return (
    <Segment clearing>
      <Form onSubmit={handleSubmit} autoComplete="off" >
        <Form.Input
          placeholder="Adi"
          value={calisan.Adi || ""}
          name="Adi"
          onChange={handleInputChange}
        />
        <Form.Input
          placeholder="Soyadi"
          value={calisan.Soyadi || ""}
          name="Soyadi"
          onChange={handleInputChange}
        />
        <Form.Input
          placeholder="Tc No"
          value={calisan.TcNo || ""}
          name="TcNo"
          onChange={handleInputChange}
        />
        <Form.Input
          placeholder="Telefon"
          value={calisan.Telefon || ""}
          name="Telefon"
          onChange={handleInputChange}
        />
        <Form.Input
          placeholder="Kullanıcı Adı"
          value={calisan.KullaniciAdi || ""}
          name="KullaniciAdi"
          onChange={handleInputChange}
        />
        <Form.Input
          placeholder="Şifre"
          value={calisan.Sifre || ""}
          name="Sifre"
          onChange={handleInputChange}
        />
        <Form.Input
          placeholder="Doğum Tarihi"
          type="date"
          value={calisan.DogumTarihi || ""}
          name="DogumTarihi"
          onChange={handleInputChange}
        />
        <Form.Select
          placeholder="Ünvan"
          value={
            calisan.UnvanID
              ? unvanlar.find((u) => u.UnvanID === calisan.UnvanID)?.UnvanID
              : 1
          }
          name="UnvanID"
          options={unvanOptions()}
          onChange={handleSelectionChange}
        />
        <Button
          loading={loading}
          floated="right"
          positive
          type="submit"
          content="Ekle"
        ></Button>
        <Button as={Link} to='/calisanlar' floated="right" type="button" content="İptal"></Button>
      </Form>
    </Segment>
  );
});
