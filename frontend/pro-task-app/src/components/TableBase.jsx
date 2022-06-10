import BootstrapTable from "react-bootstrap-table-next";
import paginationFactory from "react-bootstrap-table2-paginator";

export default function TableBase({keyField, columns, data}) {
    return (
        <BootstrapTable
            keyField={keyField ?? "id"}
            data={data}
            columns={columns}
            pagination={paginationFactory()}
        />
    )
}
