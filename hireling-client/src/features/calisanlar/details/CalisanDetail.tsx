import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { useParams } from "react-router";
import { Link } from "react-router-dom";
import {  Button, Grid, GridColumn } from "semantic-ui-react";
import LoadingCompnents from "../../../app/layout/LoadingComponent";
import { useStore } from "../../../app/stores/store";

export default observer(function CalisanDetail() {
  const { calisanStore } = useStore();
  const {
    selectedCalisan: calisan,
    loadCalisan,
    loadingInitial,
  } = calisanStore;

  const { id } = useParams<{ id: string }>();

  useEffect(() => {
    if (id) {
      loadCalisan(+id);
    }
  }, [id, loadCalisan]);

  if (loadingInitial || !calisan) {
    return <LoadingCompnents/>
  }
  return (
    <Grid>
      <GridColumn width={10}>
        <Button as={Link} to={`/duzenle/${calisan.CalisanID}`}/>
        <h1>Detail</h1>
      </GridColumn>
      <GridColumn width={6}>
        <h1>SideBar</h1>
      </GridColumn>
    </Grid>
  );
});
