// import React, { useEffect, useState } from 'react';
// import { Button, Dialog, DialogActions, DialogContent, DialogTitle, TextField, Select, MenuItem, FormControl, InputLabel, Box } from '@mui/material';
// import { useGlobalStore } from '../shared/state/globalStore';
// import { SelectChangeEvent } from '@mui/material';
// import CookDataGrid from '../components/CookDataGrid/CookDataGrid';
// import EmployeeType from '../shared/types/employee';

// const EmployeesComponent = () => {
//     const { employees, fetchEmployees, deleteEmployee, updateEmployee, createEmployee } = useGlobalStore();
//     const [open, setOpen] = useState(false);
//     const [editOpen, setEditOpen] = useState(false);
//     const [newEmployee, setNewEmployee] = useState({} as EmployeeType);
//     const [selectedEmployee, setSelectedEmployee] = useState<{
//         id: string;
//         name: string;
//         surname: string;
//         login: string;
//         password: string;
//     } | null>(null);
//     const [limit, setLimit] = useState(5);
//     const [page, setPage] = useState(1);

//     useEffect(() => {
//         fetchEmployees(page, limit);
//     }, [page, limit]);

//     const handleDelete = (id: string) => {
//         deleteEmployee(id);
//     };

//     const handleOpenEditDialog = (employee: {
//         id: string; name?: string; surname?: string;
//         login?: string; password?: string;
//     }) => {
//         setSelectedEmployee({
//             id: employee.id,
//             name: employee.name ?? '',
//             surname: employee.surname ?? '',
//             login: employee.login ?? '',
//             password: employee.password ?? '',
//         });
//         setEditOpen(true);
//     };

//     const handleCloseEdit = () => {
//         setSelectedEmployee({
//             id: '',
//             name: '',
//             surname: '',
//             login: '',
//             password: '',
//         });
//         setEditOpen(false);
//     };

//     const handleEditSave = () => {
//         if (selectedEmployee) {
//             updateEmployee(String(selectedEmployee.id), selectedEmployee);
//             handleCloseEdit();
//         } else {
//             alert("Все поля должны быть заполнены!");
//         }
//     };

//     const handleCreate = () => {
//         setOpen(true);
//     };

//     const handleClose = () => {
//         setOpen(false);
//         setNewEmployee({} as EmployeeType);
//     };

//     const handleSave = () => {
//         createEmployee(newEmployee);
//         handleClose();
//     };

//     const handleLimitChange = (event: SelectChangeEvent) => {
//         setLimit(Number(event.target.value));
//     };

//     return (
//         <>
//             <div style={{ marginTop: '1rem', marginBottom: '0.5rem', textAlign: 'center' }}>
//                 <Button
//                     id="add"
//                     variant="contained"
//                     style={{ backgroundColor: '#FFA500', color: '#fff' }}
//                     onClick={handleCreate}
//                 >
//                     Добавить
//                 </Button>
//             </div>
//             <EmployeeDataGrid
//                 employee={employees}
//                 limit={limit}
//                 handleLimitChange={handleLimitChange}
//                 page={page}
//                 setPage={setPage}
//                 handleEdit={(id, data) => handleOpenEditDialog({ id, ...data })}
//                 handleDelete={handleDelete}
//             />

//             <Dialog open={open} onClose={handleClose}>
//                 <DialogTitle>Создать сотрудника</DialogTitle>
//                 <DialogContent>
//                     <TextField
//                         margin="dense"
//                         label="Имя"
//                         type="name"
//                         fullWidth
//                         value={newEmployee.name}
//                         onChange={(e) => setNewEmployee({ ...newEmployee, name: e.target.value })}
//                     />
//                     <TextField
//                         margin="dense"
//                         label="Фамилия"
//                         type="lastName"
//                         fullWidth
//                         value={newEmployee.surname}
//                         onChange={(e) => setNewEmployee({ ...newEmployee, surname: e.target.value })}
//                     />
//                     <TextField
//                         autoFocus
//                         margin="dense"
//                         label="Логин"
//                         fullWidth
//                         value={newEmployee.login}
//                         onChange={(e) => setNewEmployee({ ...newEmployee, login: e.target.value })}
//                     />
//                     <TextField
//                         margin="dense"
//                         label="Пароль"
//                         type="password"
//                         fullWidth
//                         value={newEmployee.password}
//                         onChange={(e) => setNewEmployee({ ...newEmployee, password: e.target.value })}
//                     />
//                 </DialogContent>
//                 <DialogActions>
//                     <Button onClick={handleClose}>Отмена</Button>
//                     <Button onClick={handleSave}>Сохранить</Button>
//                 </DialogActions>
//             </Dialog>
//         </>
//     );
// };

// export default EmployeesComponent;