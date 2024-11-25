import React, { useEffect, useState } from 'react';
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, TextField } from '@mui/material';
import { SelectChangeEvent } from '@mui/material';
import WaiterDataGrid from './WaiterDataGrid';
import WaiterType from '../../shared/types/waiter';
import { useGlobalStore } from '../../shared/state/globalStore';

const EmployeesComponent = () => {
    const { waiters, fetchWaiters, deleteWaiter, updateWaiter, createWaiter } = useGlobalStore();
    const [open, setOpen] = useState(false);
    const [editOpen, setEditOpen] = useState(false);
    const [newWaiter, setNewWaiter] = useState({} as WaiterType);
    const [selectedWaiter, setSelectedWaiter] = useState<{
        id: string;
        name: string;
        surname: string;
        login: string;
        password: string;
    } | null>(null);
    const [limit, setLimit] = useState(5);
    const [page, setPage] = useState(1);

    useEffect(() => {
        fetchWaiters(page, limit);
    }, [page, limit, open, editOpen]);

    const handleDelete = (id: string) => {
        deleteWaiter(id);
    };

    const handleOpenEditDialog = (waiter: {
        id: string; name?: string; surname?: string;
        login?: string; password?: string;
    }) => {
        setSelectedWaiter({
            id: waiter.id,
            name: waiter.name ?? '',
            surname: waiter.surname ?? '',
            login: waiter.login ?? '',
            password: waiter.password ?? '',
        });
        setEditOpen(true);
    };

    const handleCloseEdit = () => {
        setSelectedWaiter({
            id: '',
            name: '',
            surname: '',
            login: '',
            password: '',
        });
        setEditOpen(false);
    };

    const handleEditSave = () => {
        if (selectedWaiter) {
            updateWaiter(String(selectedWaiter.id), selectedWaiter);
            handleCloseEdit();
        } else {
            alert("Все поля должны быть заполнены!");
        }
    };

    const handleCreate = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
        setNewWaiter({} as WaiterType);
    };

    const handleSave = () => {
        createWaiter(newWaiter);
        handleClose();
    };

    const handleLimitChange = (event: SelectChangeEvent) => {
        setLimit(Number(event.target.value));
    };

    return (
        <>
            <div style={{ marginTop: '1rem', marginBottom: '0.5rem', textAlign: 'center' }}>
                <Button
                    id="add"
                    variant="contained"
                    style={{ backgroundColor: '#FFA500', color: '#fff' }}
                    onClick={handleCreate}
                >
                    Добавить
                </Button>
            </div>
            <WaiterDataGrid
                Waiter={waiters}
                limit={limit}
                handleLimitChange={handleLimitChange}
                page={page}
                setPage={setPage}
                handleEdit={(id, data) => handleOpenEditDialog({ id, ...data })}
                handleDelete={handleDelete}
            />

            <Dialog open={open} onClose={handleClose}>
                <DialogTitle>Создать сотрудника</DialogTitle>
                <DialogContent>
                    <TextField
                        margin="dense"
                        label="Имя"
                        type="name"
                        fullWidth
                        value={newWaiter.name}
                        onChange={(e) => setNewWaiter({ ...newWaiter, name: e.target.value })}
                    />
                    <TextField
                        margin="dense"
                        label="Фамилия"
                        type="lastName"
                        fullWidth
                        value={newWaiter.surname}
                        onChange={(e) => setNewWaiter({ ...newWaiter, surname: e.target.value })}
                    />
                    <TextField
                        autoFocus
                        margin="dense"
                        label="Логин"
                        fullWidth
                        value={newWaiter.employee ? newWaiter.employee.login : ""}
                        onChange={(e) => setNewWaiter({ ...newWaiter, employee: { ...newWaiter.employee, login: e.target.value } })}
                    />
                    <TextField
                        margin="dense"
                        label="Пароль"
                        type="password"
                        fullWidth
                        value={newWaiter.employee ? newWaiter.employee.password : ""}
                        onChange={(e) => setNewWaiter({ ...newWaiter, employee: { ...newWaiter.employee, password: e.target.value } })}
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Отмена</Button>
                    <Button onClick={handleSave}>Сохранить</Button>
                </DialogActions>
            </Dialog>
        </>
    );
};

export default EmployeesComponent;