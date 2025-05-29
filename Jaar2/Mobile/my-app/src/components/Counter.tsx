import {
  Button,
  FlatList,
  GestureResponderEvent,
  ScrollView,
  StyleSheet,
  Text,
  View,
} from "react-native";
import React, {
  Dispatch,
  SetStateAction,
  useEffect,
  useRef,
  useState,
} from "react";

type UpdaterFunc = (value: number) => void;

interface Todo {
  userId: number;
  id: number;
  title: string;
  completed: boolean;
}

type TodoReadOnly = Readonly<Todo>;

interface CounterProps {
  counter: number;
  setCounter: Dispatch<SetStateAction<number>>;
}

const Counter = ({ setCounter, counter }: CounterProps) => {
  const [todos, setTodos] = useState<TodoReadOnly[]>([]);
  const listRef = useRef<FlatList<Todo>>(null);
  const handlePress = (event: GestureResponderEvent) => {
    console.log(event);
    setCounter(counter + 1);

    listRef.current?.scrollToEnd();
  };

  useEffect(() => {
    const fetchPosts = async () => {
      try {
        const response = await fetch(
          "https://jsonplaceholder.typicode.com/todos"
        );

        const data = (await response.json()) as TodoReadOnly[];
        setTodos(data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchPosts();
  }, []);

  return (
    <View style={{ flex: 1 }}>
      {/* <Text>{counter}</Text> */}

      {/* {todos.map((todo) => (
        <Text key={todo.id}>{todo.title}</Text>
      ))} */}

      <FlatList
        style={{ flex: 4 }}
        ref={listRef}
        data={todos}
        renderItem={({ item }) => {
          return <Text>{item.title}</Text>;
        }}
        keyExtractor={(item) => item.id.toString()}
      />

      <View style={{ flex: 1 }}>
        <Button title="Klik mij" onPress={handlePress}></Button>
      </View>
    </View>
  );
};

export default Counter;

const styles = StyleSheet.create({});
