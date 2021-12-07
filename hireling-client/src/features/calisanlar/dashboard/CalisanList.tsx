import { observer } from "mobx-react-lite";
import React, { Fragment } from "react";
import { Link } from "react-router-dom";
import { Header, ItemGroup, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import CalisanListItem from "./CalisanListItem";

export default observer(function CalisanList() {
  const { calisanStore, unvanStore } = useStore();
  const { GroupedCalisan } = calisanStore;

  const { unvanlar } = unvanStore;
  return (
    <>
      {GroupedCalisan.map(([group, calisanlar]) => (
        <Fragment key={group}>
          <Header sub color="teal">
            {group !== "0"
              ? unvanlar.find((u) => u.UnvanID === +group)?.UnvanAdi
              : "Ünvansız"}
          </Header>
          <Segment>
            <ItemGroup divided>
              {calisanlar.map((calisan) => (
                <CalisanListItem key={calisan.CalisanID} calisan={calisan} />
              ))}
            </ItemGroup>
          </Segment>
        </Fragment>
      ))}
    </>
  );
});
