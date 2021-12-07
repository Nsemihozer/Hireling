import React from "react";
import { Container } from "semantic-ui-react";
import NavBar from "./navBar";
import CalisanDashboard from "../../features/calisanlar/dashboard/CalisanDashboard";
import { observer } from "mobx-react-lite";
import { Route, useLocation } from "react-router-dom";
import HomePage from "../../features/home/HomePage";
import CalisanForm from "../../features/calisanlar/form/CalisanForm";
import CalisanDetail from "../../features/calisanlar/details/CalisanDetail";
function App() {
  const location = useLocation();

  return (
    <>
      <Route exact path="/" component={HomePage} />
      <Route
        path={"/(.+)"}
        render={() => (
          <>
            <NavBar />
            <Container style={{ marginTop: "7em" }}>
              <Route exact path="/calisanlar" component={CalisanDashboard} />
              <Route path="/calisanlar/:id" component={CalisanDetail} />
              <Route
                key={location.key}
                path={["/calisanEkle", "/duzenle/:id"]}
                component={CalisanForm}
              />
            </Container>
          </>
        )}
      />
    </>
  );
}

export default observer(App);
