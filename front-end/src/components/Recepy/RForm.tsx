import * as React from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import Box from '@mui/material/Box/Box';
import MenuItem from '@mui/material/MenuItem/MenuItem';
import InputLabel from '@mui/material/InputLabel/InputLabel';
import Select from '@mui/material/Select/Select';
import { useParams } from 'react-router-dom';

const AddCollectionDialog = () => {
    const token = localStorage.getItem('token');
    const [open, setOpen] = React.useState(false);
    const [name, setName] = React.useState('');
    const [description, setDescription] = React.useState('');
    const [duration, setDuration] = React.useState('');
    const [setId, setRecepyId] = React.useState('');

    const { id } = useParams();
    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const handleAdd = async () => {
        await addCollection();
        setOpen(false);
    };

    const addCollection = async (): Promise<void> => {
        
        const recepy = {
            name: name,
            description: description,
            duration: duration,
            recepySetId: id
        };
        const response = await fetch(`https://localhost:7247/recepy`, {
            headers: {
                'Content-Type': 'application/json',
                Authorization: `Bearer ${sessionStorage.getItem("token")}`
            },
            method: 'POST',
            body: JSON.stringify(recepy)
        });
        console.log(response);
        console.log(recepy);

    };

    return (
        <div>


            <Button variant="outlined" onClick={handleClickOpen}>
                Add collection
            </Button>
            <Dialog open={open} onClose={handleClose}>
                <DialogTitle>Add new collection</DialogTitle>
                <DialogContent>
                    <DialogContentText>Please enter collection title and description</DialogContentText>
                    <Box
                        component="form"
                        noValidate
                        autoComplete="off"
                        sx={{
                            '& .MuiTextField-root': { m: 1, width: '50ch' }
                        }}
                    >
                        <div>
                            <TextField onChange={(e) => setName(e.target.value)} required id="outlined-password-input" label="Name" type="text" />{' '}
                        </div>

                        <div>
                            <TextField onChange={(e) => setDescription(e.target.value)} required id="outlined-password-input" label="Description" type="text" />
                        </div>
                        <div>
                            <TextField onChange={(e) => setDuration(e.target.value)} required  id="outlined-password-input" label="Duration" type="text" />
                        </div>
                    </Box>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Cancel</Button>
                    <Button onClick={handleAdd}>Add</Button>
                </DialogActions>
            </Dialog>
        </div>
    );
};

export default AddCollectionDialog;