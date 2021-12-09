import React from "react";
import { Link } from "react-router-dom";
import {
  Item,
  ItemContent,
  ItemHeader,
  ItemDescription,
  SegmentGroup,
  Segment,
  ItemGroup,
  ItemImage,
  Icon,
} from "semantic-ui-react";
import { Calisan } from "../../../app/models/calisan";


interface Props {
  calisan: Calisan;
}

export default function ActivityListItem({ calisan }: Props) {
  return (
    <SegmentGroup>
      <Segment>
        <ItemGroup>
          <Item>
            <ItemImage size="tiny" circular src="/assets/user.png"></ItemImage>
            <ItemContent>
              <ItemHeader as={Link} to={`/calisanlar/${calisan.CalisanID}`}>
                {calisan.Adi + " " + calisan.Soyadi}
              </ItemHeader>
              <ItemDescription>{calisan.BirimID}</ItemDescription>
            </ItemContent>
          </Item>
        </ItemGroup>
      </Segment>
      <Segment>
        <Icon name="birthday" /> {calisan.DogumTarihi} <br />
        <Icon name="clock" /> {calisan.IseGirisTarihi} <br />
        <Icon name="phone" /> {calisan.Telefon}
        <br />
        <Icon name="phone" /> {calisan.Telefon}
        <br />
      </Segment>
    </SegmentGroup>
  );
}
