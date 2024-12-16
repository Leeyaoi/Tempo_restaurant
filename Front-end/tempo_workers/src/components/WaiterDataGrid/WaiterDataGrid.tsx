import React, { useState } from "react";
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
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import WaiterType from "../../shared/types/waiter";
import PaginatedType from "../../shared/types/paginatedModel";
import { useGlobalStore } from "../../shared/state/globalStore";

interface Props {
  Waiter: PaginatedType<WaiterType>;
  limit: number;
  handleLimitChange: (event: SelectChangeEvent) => void;
  page: number;
  setPage: (value: number) => void;
  handleEdit: (id: string, data: Partial<WaiterType>) => void;
  handleDelete: (id: string) => void;
}

const WaiterDataGrid = ({
  Waiter,
  limit,
  handleLimitChange,
  page,
  setPage,
  handleEdit,
  handleDelete,
}: Props) => {
  const { updateWaiter } = useGlobalStore();
  const [openEdit, setOpenEdit] = useState(false);
  const [openDelete, setOpenDelete] = useState(false);
  const [newWaiter, setNewWaiter] = useState<WaiterType>({} as WaiterType);
  const [editId, setEditId] = useState<string | null>(null);
  const [deleteId, setDeleteId] = useState<string | null>(null);


  const handleOpenEditDialog = (id: string, data: WaiterType) => {
    setEditId(id);
    setNewWaiter(data);
    setOpenEdit(true);
  };

  const handleCloseEdit = () => {
    setOpenEdit(false);
    setEditId(null);
    setNewWaiter({} as WaiterType);
  };

  const handleSave = async () => {
    console.log(editId)
    if (editId) {
      await updateWaiter(editId, newWaiter);
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

  const columns: GridColDef<WaiterType[][number]>[] = [
    {
      field: "name",
      headerName: "Имя",
      width: 180,
      editable: false,
    },
    {
      field: "surname",
      headerName: "Фамилия",
      width: 180,
      editable: false,
    },
    {
      field: "login",
      headerName: "Логин",
      renderCell: (params) => { if (params.row.employee) return params.row.employee.login },
      width: 150,
      editable: false,
    },
    {
      field: "password",
      headerName: "Пароль",
      renderCell: (params) => { if (params.row.employee) return params.row.employee.password },
      width: 150,
      editable: false,
    },
    {
      field: "actions",
      headerName: "Действия",
      width: 190,
      renderCell: (params) => (
        <>
          <Button
            style={{ marginRight: '0.5rem' }}
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
          rows={Waiter ? Waiter.items : []}
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
          Всего записей: {Waiter ? Waiter.total : 0}
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
            {Waiter ? Waiter.page : 0} .. {Waiter ? Waiter.pageCount : 0}
          </p>
          <Button
            variant="contained"
            onClick={() => setPage(Math.min(Waiter.pageCount, page + 1))}
          >
            <KeyboardArrowRightIcon />
          </Button>
          <Button
            variant="contained"
            onClick={() => setPage(Waiter.pageCount)}
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
            label="Имя"
            fullWidth
            value={newWaiter.name}
            onChange={(e) => setNewWaiter({ ...newWaiter, name: e.target.value })}
          />
          <TextField
            autoFocus
            margin="dense"
            label="Фамилия"
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
            type="text"
            fullWidth
            value={newWaiter.employee ? newWaiter.employee.password : ""}
            onChange={(e) => setNewWaiter({ ...newWaiter, employee: { ...newWaiter.employee, password: e.target.value } })}
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

export default WaiterDataGrid;