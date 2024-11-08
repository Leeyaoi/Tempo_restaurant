import React, { useState } from "react";
import './EmployeeDataGrid.scss';
import {
  Button,
  FormControl,
  MenuItem,
  Select,
  SelectChangeEvent,
  Dialog,
  DialogTitle,
  DialogContent,
  TextField,
  DialogActions,
} from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import KeyboardDoubleArrowLeftIcon from "@mui/icons-material/KeyboardDoubleArrowLeft";
import KeyboardArrowLeftIcon from "@mui/icons-material/KeyboardArrowLeft";
import KeyboardArrowRightIcon from "@mui/icons-material/KeyboardArrowRight";
import KeyboardDoubleArrowRightIcon from "@mui/icons-material/KeyboardDoubleArrowRight";
import EmployeeType from "../shared/types/employee";
import PaginatedType from "../shared/types/paginatedModel";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";

interface Props {
  employee: PaginatedType<EmployeeType>;
  limit: number;
  handleLimitChange: (event: SelectChangeEvent) => void;
  page: number;
  setPage: (value: number) => void;
  handleEdit: (id: string, data: Partial<EmployeeType>) => void;
  handleDelete: (id: string) => void;
}

const EmployeeDataGrid = ({
  employee,
  limit,
  handleLimitChange,
  page,
  setPage,
  handleEdit,
  handleDelete,
}: Props) => {
  const [openEdit, setOpenEdit] = useState(false);
  const [openDelete, setOpenDelete] = useState(false);
  const [newEmployee, setNewEmployee] = useState<EmployeeType>({
    login: "",
    password: "",
  });
  const [editId, setEditId] = useState<string | null>(null);
  const [deleteId, setDeleteId] = useState<string | null>(null);

  const handleOpenEditDialog = (id: string, data: EmployeeType) => {
    setEditId(id);
    setNewEmployee(data);
    setOpenEdit(true);
  };

  const handleCloseEdit = () => {
    setOpenEdit(false);
    setEditId(null);
    setNewEmployee({ login: "", password: "" });
  };

  const handleSave = () => {
    if (editId) {
      handleEdit(editId, newEmployee);
    }
    handleCloseEdit();
  };

  const handleOpenDeleteDialog = (id: string) => {
    setDeleteId(id);
    setOpenDelete(true);
  };

  const handleCloseDelete = () => {
    setOpenDelete(false);
    setDeleteId(null);
  };

  const handleConfirmDelete = () => {
    if (deleteId) {
      handleDelete(deleteId);
    }
    handleCloseDelete();
  };

  const columns: GridColDef<EmployeeType[][number]>[] = [
    {
      field: "login",
      headerName: "Логин",
      width: 240,
      editable: false,
    },
    {
      field: "password",
      headerName: "Пароль",
      width: 240,
      editable: false,
    },
    {
      field: "actions",
      headerName: "Действия",
      width: 240,
      renderCell: (params) => (
        <>
          <Button
            style={{ marginRight: '0.5rem'}}
            color="success"
            variant="contained"
            id="actionButton"
            onClick={() => handleOpenEditDialog(params.id as string, params.row)}
          >
            <EditIcon />
          </Button>
          <Button
            color="error"
            onClick={() => handleOpenDeleteDialog(params.id as string)}
            variant="contained"
            id="actionButton"
          >
            <DeleteIcon />
          </Button>
        </>
      ),
    },
  ];

  return (
    <>
      <div>
        <DataGrid
          rows={employee ? employee.items : []}
          columns={columns}
          disableRowSelectionOnClick
          hideFooter={true}
        />
      </div>
      <div id="pagination-size-control">
        <p>Размер страницы:</p>
        <FormControl variant="standard">
          <Select
            className="text-input"
            value={limit.toString()}
            onChange={handleLimitChange}
          >
            <MenuItem key={5} value={5}>
              5
            </MenuItem>
            <MenuItem key={10} value={10}>
              10
            </MenuItem>
          </Select>
        </FormControl>
        <p id="total_data">
          Всего записей: {employee ? employee.total : 0}
        </p>
        <div id="pagination-control">
          <Button
            variant="contained"
            onClick={() => setPage(1)}
          >
            <KeyboardDoubleArrowLeftIcon />
          </Button>
          <Button
            variant="contained"
            onClick={() => setPage(Math.max(1, page - 1))}
          >
            <KeyboardArrowLeftIcon />
          </Button>
          <p>
            {employee ? employee.page : 0} .. {employee ? employee.pageCount : 0}
          </p>
          <Button
            variant="contained"
            onClick={() => setPage(Math.min(employee.pageCount, page + 1))}
          >
            <KeyboardArrowRightIcon />
          </Button>
          <Button
            variant="contained"
            onClick={() => setPage(employee.pageCount)}
          >
            <KeyboardDoubleArrowRightIcon />
          </Button>
        </div>
      </div>

      <Dialog open={openEdit} onClose={handleCloseEdit}>
        <DialogTitle>Редактировать сотрудника</DialogTitle>
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
            type="text"
            fullWidth
            value={newEmployee.password}
            onChange={(e) => setNewEmployee({ ...newEmployee, password: e.target.value })}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseEdit}>Отмена</Button>
          <Button onClick={handleSave}>Сохранить</Button>
        </DialogActions>
      </Dialog>

      <Dialog open={openDelete} onClose={handleCloseDelete}>
        <DialogTitle>Подтверждение удаления</DialogTitle>
        <DialogContent>
          <p>Вы уверены, что хотите удалить этого сотрудника?</p>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseDelete}>Отмена</Button>
          <Button color="error" onClick={handleConfirmDelete}>
            Удалить
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export default EmployeeDataGrid;


