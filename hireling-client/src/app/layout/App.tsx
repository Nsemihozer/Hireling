import React, { useEffect } from "react";
import { Container } from "semantic-ui-react";
import NavBar from "./navBar";
import CalisanDashboard from "../../features/calisanlar/dashboard/CalisanDashboard";
import { observer } from "mobx-react-lite";
import { Route, Switch, useLocation } from "react-router-dom";
import HomePage from "../../features/home/HomePage";
import CalisanForm from "../../features/calisanlar/form/CalisanForm";
import CalisanDetail from "../../features/calisanlar/details/CalisanDetail";
import NotFound from "../../features/errors/NotFound";
import ServerError from "../../features/errors/ServerError";
import LoginForm from "../../features/users/LoginForm";
import { useStore } from "../stores/store";
import LoadingCompnents from "./LoadingComponent";
import ModalContainer from "../common/modals/ModalContainer";
import { ToastContainer } from "react-toastify";
function App() {
  const location = useLocation();
  const { commonStore, userStore } = useStore();

  useEffect(() => {
    if (commonStore.token) {
      userStore.getUser().finally(() => commonStore.setAppLoaded());
    } else {
      commonStore.setAppLoaded();
    }
  }, [commonStore, userStore]);

  if (!commonStore.appLoaded) {
    return <LoadingCompnents content="Yükleniyor" />;
  }
  return (
    <>
      <ToastContainer
        position="bottom-right"
        autoClose={1500}
        hideProgressBar={false}
      />
      <ModalContainer />
      <Route exact path="/" component={HomePage} />
      <Route
        path={"/(.+)"}
        render={() => (
          <>
            <NavBar />
            <Container style={{ marginTop: "7em" }}>
              <Switch>
                <Route exact path="/calisanlar" component={CalisanDashboard} />
                <Route path="/calisanlar/:id" component={CalisanDetail} />
                <Route
                  key={location.key}
                  path={["/calisanEkle", "/duzenle/:id"]}
                  component={CalisanForm}
                />
                <Route path="/server-error" component={ServerError} />
                <Route path="/login" component={LoginForm} />
                <Route component={NotFound} />
              </Switch>
            </Container>
          </>
        )}
      />
    </>
  );
}

export default observer(App);
