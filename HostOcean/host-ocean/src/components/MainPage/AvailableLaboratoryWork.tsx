import React from "react";
import { TableRow, Paper, Table, TableHead, TableCell, TableBody } from "@material-ui/core";
import { labsStab } from "../../Core/LabsStab";
import { LaboratoryWork } from "../../Core/LaboratoryWork/LaboratoryWorkModel";
import Checkbox from '@material-ui/core/Checkbox';

export interface Props {
}

export interface State {
    laboratoryWorks: LaboratoryWork[];
}

export class AvailableLaboratoryWorkContainer extends React.Component<Props, State> {
    constructor(props: Props) {
        super(props);
        this.state = {
            laboratoryWorks: [],
        };
    }
    public componentDidMount() {
        this.setState({
            laboratoryWorks: labsStab,
        });
    }
    public render() {
        const { laboratoryWorks } = this.state;
        return (<div>
            <Paper >
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell align="center">Лаборатоные</TableCell>
                            <TableCell align="center">Какие будете сдавать</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {laboratoryWorks.map((item) => (
                            <TableRow key={item.id}>
                                <TableCell align="center">{item.title}</TableCell>
                                <TableCell align="center"><Checkbox/></TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </Paper>
        </div>);
    }
}

export const AvailableLaboratoryWork = AvailableLaboratoryWorkContainer;