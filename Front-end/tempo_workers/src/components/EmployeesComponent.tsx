import React, { useEffect, useState } from 'react';
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, TextField } from '@mui/material';
import { useGlobalStore } from '../shared/state/globalStore';
import { SelectChangeEvent } from '@mui/material';
import EmployeeDataGrid from './EmployeeDataGrid';

const EmployeesComponent = () => {
    const { employees, fetchEmployees, deleteEmployee, updateEmployee, createEmployee } = useGlobalStore();
    const [open, setOpen] = useState(false);
    const [newEmployee, setNewEmployee] = useState({ login: '', password: '' });
    const [limit, setLimit] = useState(5);
    const [page, setPage] = useState(1);

    useEffect(() => {
        fetchEmployees(page, limit);
    }, [page, limit]);

    const handleDelete = (id: string | number) => {
        deleteEmployee(id);
    };

    const handleEdit = (id: string | number) => {
        const newLogin = prompt("Введите новый логин:");
        const newPassword = prompt("Введите новый пароль:");
        if (newLogin && newPassword) {
            updateEmployee(id, { login: newLogin, password: newPassword });
        }
    };

    const handleCreate = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
        setNewEmployee({ login: '', password: '' });
    };

    const handleSave = () => {
        createEmployee(newEmployee);
        handleClose();
    };

    const handleLimitChange = (event: SelectChangeEvent) => {
        setLimit(Number(event.target.value));
    };

    const handleOpenEdit = (id: string) => {
        handleEdit(id);
    };

    const handleOpenDelete = (id: string) => {
        handleDelete(id);
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
            <EmployeeDataGrid
                employee={employees}
                limit={limit}
                handleLimitChange={handleLimitChange}
                page={page}
                setPage={setPage}
                handleEdit={handleOpenEdit}
                handleDelete={handleOpenDelete}
            />

            <Dialog open={open} onClose={handleClose}>
                <DialogTitle>Создать сотрудника</DialogTitle>
                <DialogContent>
                    <TextField
                        autoFocus
                        margin="dense"
                        label="Логин"
                        fullWidth
                        value={newEmployee.login}
                        onChange={(e) => setNewEmployee({ ...newEmployee, login: e.target.value })}
                    />
                    <TextField
                        margin="dense"
                        label="Пароль"
                        type="password"
                        fullWidth
                        value={newEmployee.password}
                        onChange={(e) => setNewEmployee({ ...newEmployee, password: e.target.value })}
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Отмена</Button>
                    <Button onClick={handleSave}>Сохранить</Button>
                </DialogActions>
            </Dialog>
        </>
    );
}

const paginationModel = { page: 0, pageSize: 5 };

export default EmployeesComponent;