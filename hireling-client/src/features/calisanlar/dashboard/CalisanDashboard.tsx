import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Grid, GridColumn } from "semantic-ui-react";
import LoadingCompnents from "../../../app/layout/LoadingComponent";
import { useStore } from "../../../app/stores/store";
import CalisanFilter from "./CalisanFilter";
import CalisanList from "./CalisanList";

export default observer(function CalisanDashboard() {

  
  const {calisanStore,unvanStore}=useStore();
  const {loadCalisanlar,calisanlarRegistry}=calisanStore;
  useEffect(() => {
   if (calisanlarRegistry.size <1) {
    loadCalisanlar();
   } 
  }, [calisanlarRegistry.size,loadCalisanlar]);

  useEffect(() => {
    if (unvanStore.unvanlar.length<1) {
      unvanStore.loadUnvanlar();
    } 
  }, [unvanStore]);



  if (calisanStore.loadingInitial)
    return <LoadingCompnents content="Yükleniyor"></LoadingCompnents>;
  return (
    <Grid>
      <GridColumn width="10">
        <CalisanList
        />
      </GridColumn>
      <GridColumn width="6">
        <CalisanFilter/>
      </GridColumn>
    </Grid>
  );
});
