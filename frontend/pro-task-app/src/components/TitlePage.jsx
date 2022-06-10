export default function TitlePage({title, children}) {
    return (
        <div className="d-flex justify-content-between align-items-end mt-3 pb-3 border-bottom border-dark">
            <h1 className="page-title">{title}</h1>
            {children}
        </div>
    )
}
