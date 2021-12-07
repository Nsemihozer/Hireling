import React from "react";
import { Dimmer, Loader } from "semantic-ui-react";

interface Props{
    inverted?:boolean;
    content?:string;
}

export default function LoadingCompnents({inverted=true,content='Yükleniyor'}:Props) {

    return(
        <Dimmer active={true} inverted={inverted}>
            <Loader content={content}></Loader>
        </Dimmer>
    )
    
}