import React from "react";
import { Link } from "react-router-dom";
import { Button, Container, Header, Image, Segment } from "semantic-ui-react";

export default function HomePage() {
  return (
    <Segment inverted textAlign="center" vertical className="masthead">
      <Container text>
          <Header as='h1' inverted>
              <Image size='massive' src='/assets/logo.png' alt='logo' style={{marginBottm:12}}/>
              Hireling
          </Header>
          <Header as='h2' inverted content='Hireling Hoş geldiniz'></Header>
          <Button as={Link} to='/calisanlar' size='huge' inverted>
              Çalışanlara Git
          </Button>
      </Container>
    </Segment>
  );
}
