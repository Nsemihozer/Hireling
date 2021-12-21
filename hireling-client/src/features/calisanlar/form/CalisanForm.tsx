import { Formik, Form, FormikErrors, ErrorMessage } from "formik";
import { observer } from "mobx-react-lite";
import React, { useEffect, useState } from "react";
import { Link, useHistory, useParams } from "react-router-dom";
import { Button, Header, Label, Segment } from "semantic-ui-react";
import LoadingCompnents from "../../../app/layout/LoadingComponent";
import { Calisan } from "../../../app/models/calisan";
import { useStore } from "../../../app/stores/store";
import * as Yup from "yup";
import MyTextInput from "../../../app/common/form/MyTextInput";
import MySelectInput from "../../../app/common/form/MySelectInput";
import MyDateInput from "../../../app/common/form/MyDateInput";
import ValidationErrors from "../../errors/ValidationErrors";
import "react-toastify/dist/ReactToastify.min.css";
import { toast } from "react-toastify";
export default observer(function CalisanForm() {
  const { calisanStore, unvanStore } = useStore();
  const { createCalisan, loading, editCalisan, loadCalisan, loadingInitial } =
    calisanStore;
  const { unvanlar, loadUnvanlar } = unvanStore;
  const { id } = useParams<{ id: string }>();

  const [calisan, setCalisan] = useState<Calisan>({
    Adi: "",
    Soyadi: "",
    TcNo: "",
    Telefon: "",
    UserName: "",
    Email: "",
    Sifre: "",
  } as Calisan);

  const validationScheme = Yup.object({
    calisan: Yup.object({
      Adi: Yup.string().required("Adı Zorunludur"),
      Soyadi: Yup.string().required("Soyadi Zorunludur"),
      TcNo: Yup.string().required("TcNo Zorunludur"),
      Telefon: Yup.string().required("Telefon Zorunludur"),
      UserName: Yup.string().when("showUserName", {
        is: true,
        then: Yup.string().required("Kullanıcı Adı Zorunludur"),
      }),
      Email: Yup.string().email("Geçersiz Eposta").required("Email Zorunludur"),
      Sifre: Yup.string().when("showPass", {
        is: true,
        then: Yup.string().required("Şifre Zorunludur"),
      }),
      DogumTarihi: Yup.string().required("Doğum Tarihi Zorunludur"),
    }),
  });

  useEffect(() => {
    if (id) {
      loadCalisan(+id).then((calisan) => setCalisan(calisan!));
    }
  }, [id, loadCalisan]);

  useEffect(() => {
    if (unvanlar.length === 0) {
      loadUnvanlar();
    }
  }, [unvanlar, loadUnvanlar]);

  const unvanOptions = () => {
    const options: { text: string; value: number }[] = [];
    unvanlar.forEach((u) => {
      options.push({ text: u.UnvanAdi, value: u.UnvanID });
    });
    return options;
  };
  const history = useHistory();
  const handleFormSubmit = async (calisan: Calisan) => {
    if (calisan.Id) {
      await editCalisan(calisan)
        .then(
          () => history.push(`/calisanlar/${calisan.Id}`),
          (error: any) => {
            if (error.hasOwnProperty("errors")) {
              throw error;
            }
          }
        )
        .catch((error) => {
          if (error.hasOwnProperty("errors")) {
            throw error;
          }
        });
    } else {
      createCalisan(calisan).then((id) =>
        id !== undefined
          ? history.push(`/calisanlar/${id}`)
          : alert("Hata oluştu")
      );
    }
  };

  if (loadingInitial) return <LoadingCompnents></LoadingCompnents>;

  return (
    <Segment clearing>
      <Header content="Çalışan Detayları" color="teal" sub></Header>
      <Formik
        enableReinitialize
        initialValues={{
          calisan,
          error: null,
          showPass: calisan.Id ? false : true,
          showUserName: calisan.Id ? false : true,
        }}
        onSubmit={(values, { setErrors }) =>
          handleFormSubmit(values.calisan).catch((error: any) =>
            setErrors({ error })
          )
        }
        validationSchema={validationScheme}
      >
        {({ handleSubmit, isValid, isSubmitting, dirty, errors }) => (
          <Form onSubmit={handleSubmit} autoComplete="off" className="ui form">
            <MyTextInput placeholder="Adi" name="calisan.Adi" />
            <MyTextInput placeholder="Soyadi" name="calisan.Soyadi" />
            <MyTextInput placeholder="Tc No" name="calisan.TcNo" />
            <MyTextInput placeholder="Telefon" name="calisan.Telefon" />
            {!calisan.Id && (
              <MyTextInput
                placeholder="Kullanıcı Adı"
                name="calisan.UserName"
              />
            )}
            <MyTextInput placeholder="Email" name="calisan.Email" />
            {!calisan.Id && (
              <MyTextInput placeholder="Şifre" name="calisan.Sifre" />
            )}
            <MyDateInput
              placeholderText="Doğum Tarihi"
              name="calisan.DogumTarihi"
              showTimeSelect
              timeCaption="zaman"
              dateFormat="dd MM yyyy H:mm"
            />
            <MySelectInput
              placeholder="Ünvan"
              name="calisan.UnvanID"
              options={unvanOptions()}
            ></MySelectInput>
            <ErrorMessage
              name="error"
              render={() => (
                <Label
                  style={{ marginBottom: 10 }}
                  basic
                  color="red"
                  content={errors.error}
                />
              )}
            />
            <Button
              loading={loading}
              floated="right"
              positive
              type="submit"
              content="Ekle"
              disabled={!isValid || isSubmitting || !dirty}
            ></Button>
            <Button
              as={Link}
              to="/calisanlar"
              floated="right"
              type="button"
              content="İptal"
            ></Button>
          </Form>
        )}
      </Formik>
    </Segment>
  );
});
