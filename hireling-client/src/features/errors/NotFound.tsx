import React from "react";
import { Link } from "react-router-dom";
import { Button, Header, Icon, Segment, SegmentInline } from "semantic-ui-react";

export default function NotFound() {
    return(
        <Segment placeholder>
            <Header icon>
                <Icon name='search'/>
                Aradığınız şeyi bulamadık
            </Header>
            <SegmentInline>
                <Button as={Link} to='/calisanlar' primary>
                    Çalışanlar Sayfası
                </Button>
            </SegmentInline>
        </Segment>
    )
}