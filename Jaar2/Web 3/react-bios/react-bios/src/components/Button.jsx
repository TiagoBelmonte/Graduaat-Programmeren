const Button = (props) => {
  const { onClick, children } = props;
  return (
    <button
      onClick={onClick}
      className="px-4 py-2 bg-teal-500 hover:bg-teal-300 rounded-lg text-white"
    >
      {children}
    </button>
  );
};

export default Button;
