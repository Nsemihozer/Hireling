import { ErrorMessage, Form, Formik } from "formik";
import { observer } from "mobx-react-lite";
import React from "react";
import { Button, Label } from "semantic-ui-react";
import MyTextInput from "../../app/common/form/MyTextInput";
import { useStore } from "../../app/stores/store";

export default observer(function LoginForm() {
  const { userStore } = useStore();
  return (
    <Formik
      initialValues={{ Email: "", Password: "", error: null }}
      onSubmit={(values, { setErrors }) =>
        userStore
          .login(values)
          .catch((error) => setErrors({ error: "Geçersiz eposta ya da şifre" }))
      }
    >
      {({ handleSubmit, isSubmitting,errors }) => (
        <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
          <MyTextInput name="Email" placeholder="Email" />
          <MyTextInput name="Password" placeholder="Şifre" type="password" />
          <ErrorMessage name='error'  render={()=> <Label style={{marginBottom:10}} basic color='red' content={errors.error} /> } />
          <Button
            loading={isSubmitting}
            positive
            content="Giriş Yap"
            type="submit"
            fluid
          />
        </Form>
      )}
    </Formik>
  );
});
