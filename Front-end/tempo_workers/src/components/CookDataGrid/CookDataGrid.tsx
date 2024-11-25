import React, { useEffect, useState } from "react";
import './CookDataGrid.scss';
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
import PaginatedType from "../../shared/types/paginatedModel";
import CookType from "../../shared/types/cook";
import { useGlobalStore } from "../../shared/state/globalStore";

interface Props {
  cook: PaginatedType<CookType>;
  limit: number;
  handleLimitChange: (event: SelectChangeEvent) => void;
  page: number;
  setPage: (value: number) => void;
  handleEdit: (id: string, data: Partial<CookType>) => void;
  handleDelete: (id: string) => void;
}

const CookDataGrid = ({
  cook,
  limit,
  handleLimitChange,
  page,
  setPage,
  handleEdit,
  handleDelete,
}: Props) => {
  const { updateCook, fetchCategory, Category } = useGlobalStore();
  // const { Category } = useGlobalStore();
  // const { fetchCategory } = useGlobalStore();
  const [openEdit, setOpenEdit] = useState(false);
  const [openDelete, setOpenDelete] = useState(false);
  const [newCook, setNewCook] = useState<CookType>({} as CookType);
  const [editId, setEditId] = useState<string | null>(null);
  const [deleteId, setDeleteId] = useState<string | null>(null);

  useEffect(() => { fetchCategory() },
    []
  )

  const handleOpenEditDialog = (id: string, data: CookType) => {
    setEditId(id);
    setNewCook(data);
    setOpenEdit(true);
  };

  const handleCloseEdit = () => {
    setOpenEdit(false);
    setEditId(null);
    setNewCook({} as CookType);
  };

  const handleSave = async () => {
    console.log(editId)
    if (editId) {
      await updateCook(editId, newCook);
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

  const handleCategoryChange = (event: SelectChangeEvent) => {
    setNewCook({ ...newCook, categoryId: event.target.value })
  };

  const renderCategory = () => {
    const items: any[] = [];
    for (let i in Category.items) {
      let value = Category.items[i];
      if (value == null) {
        continue;
      }
      items.push(
        <MenuItem
          key={`${value.id}`}
          value={value.id}
        >{`${value.name}`}</MenuItem>
      )
    }
    return items;
  }

  const columns: GridColDef<CookType[][number]>[] = [
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
      field: "category",
      headerName: "Категория",
      renderCell: (params) => { if (params.row.category) return params.row.category.name },
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
            onClick={() => handleOpenEditDialog(params.row.id as string, params.row)}
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
          rows={cook ? cook.items : []}
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
          Всего записей: {cook ? cook.total : 0}
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
            {cook ? cook.page : 0} .. {cook ? cook.pageCount : 0}
          </p>
          <Button
            variant="contained"
            onClick={() => setPage(Math.min(cook.pageCount, page + 1))}
          >
            <KeyboardArrowRightIcon />
          </Button>
          <Button
            variant="contained"
            onClick={() => setPage(cook.pageCount)}
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
            value={newCook.name}
            onChange={(e) => setNewCook({ ...newCook, name: e.target.value })}
          />
          <TextField
            autoFocus
            margin="dense"
            label="Фамилия"
            fullWidth
            value={newCook.surname}
            onChange={(e) => setNewCook({ ...newCook, surname: e.target.value })}
          />
          <TextField
            autoFocus
            margin="dense"
            label="Логин"
            fullWidth
            value={newCook.employee ? newCook.employee.login : ""}
            onChange={(e) => setNewCook({ ...newCook, employee: { ...newCook.employee, login: e.target.value } })}
          />
          <TextField
            margin="dense"
            label="Пароль"
            type="text"
            fullWidth
            value={newCook.employee ? newCook.employee.password : ""}
            onChange={(e) => setNewCook({ ...newCook, employee: { ...newCook.employee, password: e.target.value } })}
          />

          <FormControl fullWidth variant="standard">
            <Select
              className="text-input"
              value={newCook.categoryId ?? ""}
              onChange={handleCategoryChange}
            >
              {renderCategory()}
            </Select>
          </FormControl>

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

export default CookDataGrid;
