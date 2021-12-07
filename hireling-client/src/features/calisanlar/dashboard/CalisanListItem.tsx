import React, { SyntheticEvent, useState } from "react";
import { Link } from "react-router-dom";
import { Item, ItemContent, ItemHeader, ItemMeta, ItemDescription, ItemExtra, Button, Label } from "semantic-ui-react";
import { Calisan } from "../../../app/models/calisan";
import { useStore } from "../../../app/stores/store";

interface Props {
    calisan : Calisan;
}

export default function ActivityListItem({calisan}:Props) {

    const [target, settarget] = useState("");
    const { calisanStore, unvanStore } = useStore();
    const {unvanlar} = unvanStore;
    const {  loading, deleteCalisan } = calisanStore;
    function handeDeleteCalisan(
      e: SyntheticEvent<HTMLButtonElement>,
      id: number
    ) {
      settarget(e.currentTarget.name);
      deleteCalisan(id);
    }

    return(
        <Item key={calisan.CalisanID}>
            <ItemContent>
              <ItemHeader as="a">
                {calisan.Adi + " " + calisan.Soyadi}
              </ItemHeader>
              <ItemMeta>{calisan.DogumTarihi}</ItemMeta>
              <ItemDescription>
                {calisan.Telefon + " " + calisan.TcNo}
              </ItemDescription>
              <ItemExtra>
                <Button
                  as={Link}
                  to={`/calisanlar/${calisan.CalisanID}`}
                  floated="right"
                  content="Görüntüle"
                  color="blue"
                />
                <Button
                  loading={loading && target === calisan.CalisanID.toString()}
                  name={calisan.CalisanID}
                  floated="right"
                  content="Sil"
                  color="red"
                  onClick={(e) => handeDeleteCalisan(e, calisan.CalisanID)}
                />
                <Label
                  basic
                  content={
                    calisan.UnvanID
                      ? unvanlar.find(
                          (u) => u.UnvanID === calisan.UnvanID
                        )?.UnvanAdi
                      : "Mavi Yaka"
                  }
                ></Label>
              </ItemExtra>
            </ItemContent>
          </Item>
    )
}