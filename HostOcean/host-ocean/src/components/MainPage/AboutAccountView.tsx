import React from "react";
import { AboutAccountViewModel } from "./AboutAccountViewModel";
import { Typography } from "@material-ui/core";

interface Props {
    account: AboutAccountViewModel;
}

export class AboutAccountView extends React.Component<Props> {
   public render(){
       const { account } = this.props;
       return(
           <div>
               <Typography align={"right"} variant={"h5"} >
                   {account.name}
               </Typography>
               <Typography align={"right"} variant={"h5"} >
                   {account.surname}
               </Typography>
               <Typography align={"right"} variant={"h5"} >
                   {account.groupId}
               </Typography>       
           </div>
       );
   }

}