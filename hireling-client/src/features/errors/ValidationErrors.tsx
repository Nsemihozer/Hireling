import React from "react";
import { Message, MessageItem, MessageList } from "semantic-ui-react";
interface Props{
    errors:string[];
}

export default function ValidationErrors({errors}:Props) {
    return(
        <Message error>
            {errors && (
                <MessageList>
                    {errors.map((err:any,i)=>{
                        <MessageItem key={i}></MessageItem>
                    })}
                </MessageList>
            )}
        </Message>
    )
}