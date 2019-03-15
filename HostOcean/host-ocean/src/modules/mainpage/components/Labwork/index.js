import React from "react";
import { TableRow, Paper, Table, TableHead, TableCell, TableBody } from "@material-ui/core";
import Checkbox from '@material-ui/core/Checkbox';

const LaboratoryWorks = ({ laboratoryWorks }) => {
    return (
        <div>
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
                                <TableCell align="center"><Checkbox /></TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </Paper>
        </div>);
}

export default LaboratoryWorks;