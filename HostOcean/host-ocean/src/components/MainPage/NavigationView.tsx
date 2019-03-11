import React from 'react';
import Link from '@material-ui/core/Link';
import { Typography } from '@material-ui/core';

interface Props {
  
}

export class NavigationView extends React.Component<Props> {
    public render(){

        return(
            <div>
                <Link
                    component="button"
                    variant="body2"
                    onClick={() => {
                     window.open("http://localhost:3001/statistic");
                    }}
                >
                    Cтатистика
                </Link>
                <Link
                    component="button"
                    variant="body2"
                    onClick={() => {
                        window.open("http://localhost:3001/queue");
                    }}
                >
                   Текущая очередь
                </Link>
                <Link
                    component="button"
                    variant="body2"
                    onClick={() => {
                        window.open("http://localhost:3001/setting");
                    }}
                >
                    Настройки 
                </Link>
               
            </div>
        );
    }
 
 }


// export default function ButtonLink() {
//   return (
//     <Link
//       component="button"
//       variant="body2"
//       onClick={() => {
//         alert("I'm a button.");
//       }}
//     >
//       Button Link
//     </Link>
//   );
// }