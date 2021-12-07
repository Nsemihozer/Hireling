import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { useParams } from "react-router";
import { Link } from "react-router-dom";
import { Card, Image, Button, ButtonGroup } from "semantic-ui-react";
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
    <Card fluid>
      <Image src="/assets/categoryimages/food.jpg" alt="" />
      <Card.Content>
        <Card.Header>{calisan.Adi}</Card.Header>
        <Card.Meta>
          <span className="date">{calisan.DogumTarihi}</span>
        </Card.Meta>
        <Card.Description>{calisan.Telefon}</Card.Description>
      </Card.Content>
      <Card.Content extra>
        <ButtonGroup widths="2">
          <Button as={Link} to={`/duzenle/${calisan.CalisanID}`} basic color="blue" content="Düzenle" />
          <Button as={Link} to={'/calisanlar'} basic color="grey" content="İptal" />
        </ButtonGroup>
      </Card.Content>
    </Card>
  );
});
