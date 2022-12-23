import * as React from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';

import Box from '@mui/material/Box/Box';

const RecepyEdit = (props: any) => {
    const token = localStorage.getItem('token');
    const [open, setOpen] = React.useState(false);
    const [name, setName] = React.useState('');
    const [type, setType] = React.useState('');


    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const handleEdit = async () => {
        await addCollection();
        setOpen(false);
    };

    const addCollection = async (): Promise<void> => {
        const recepy = {
            name: name,
            type: type,

        };
        const response = await fetch(`https://localhost:7247/recepyset/${props.props}`, {
            headers: {
                'Content-Type': 'application/json',
                Authorization: `Bearer ${sessionStorage.getItem("token")}`
            },
            method: 'PUT',
            body: JSON.stringify(recepy)
        });
        console.log(response);
    };

    return (
        <div>
            <Button  size="small" onClick={handleClickOpen}>
                Koreguoti
            </Button>
            <Dialog open={open} onClose={handleClose}>
                <DialogTitle>Koreguoti receptų rinkinį</DialogTitle>
                <DialogContent>
                    <DialogContentText>Koreguokite pavadinimą arba tipą</DialogContentText>
                    <Box
                        component="form"
                        noValidate
                        autoComplete="off"
                        sx={{
                            '& .MuiTextField-root': { m: 1, width: '50ch' }
                        }}
                    >
                        <div>
                            <TextField onChange={(e) => setName(e.target.value)} required id="outlined-password-input" label="Pavadinimas" type="text" />{' '}
                        </div>
                        <div>
                            <TextField onChange={(e) => setType(e.target.value)}  required id="outlined-password-input" label="Tipas" type="text" />
                        </div>
                        
                    </Box>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Cancel</Button>
                    <Button onClick={handleEdit}>Save</Button>
                </DialogActions>
            </Dialog>
        </div>
    );
};

export default RecepyEdit;